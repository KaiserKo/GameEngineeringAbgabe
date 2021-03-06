﻿using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fusee.Tutorial.Core
{
    class Renderer : SceneVisitor
    {
        //public ShaderEffect ShaderEffect;

        public RenderContext RC;
        //private ITexture _leafTexture;
        public float4x4 View;
        private Dictionary<MeshComponent, Mesh> _meshes = new Dictionary<MeshComponent, Mesh>();
        private CollapsingStateStack<float4x4> _model = new CollapsingStateStack<float4x4>();
        public IShaderParam AlbedoParam;
        public IShaderParam ShininessParam;
        public IShaderParam ShininessFactorParam;
        public ShaderProgram shader;

        private Mesh LookupMesh(MeshComponent mc)
        {
            Mesh mesh;
            if (!_meshes.TryGetValue(mc, out mesh))
            {
                mesh = new Mesh
                {
                    Vertices = mc.Vertices,
                    Normals = mc.Normals,
                    UVs = mc.UVs,
                    Triangles = mc.Triangles,
                };
                _meshes[mc] = mesh;
            }
            return mesh;
        }

        public Renderer(RenderContext rc)
        {
            RC = rc;

            var vertsh = AssetStorage.Get<string>("VertexShader.vert");
            var pixsh = AssetStorage.Get<string>("PixelShader.frag");
            shader = RC.CreateShader(vertsh, pixsh);

            RC.SetShader(shader);

            AlbedoParam = RC.GetShaderParam(shader, "albedo");
            ShininessParam = RC.GetShaderParam(shader, "shininess");
            ShininessFactorParam = RC.GetShaderParam(shader, "shininessFactor");
        }

        protected override void InitState()
        {
            _model.Clear();
            _model.Tos = float4x4.Identity;
        }
        protected override void PushState()
        {
            _model.Push();
        }
        protected override void PopState()
        {
            _model.Pop();
            RC.ModelView = View * _model.Tos;
        }
        [VisitMethod]
        void OnMesh(MeshComponent mesh)
        {
            RC.Render(LookupMesh(mesh));
        }
        [VisitMethod]
        void OnMaterial(MaterialComponent material)
        {
            RC.SetShaderParam(AlbedoParam, material.Diffuse.Color);
            RC.SetShaderParam(ShininessParam, material.Specular.Shininess);
        }
        [VisitMethod]
        void OnTransform(TransformComponent xform)
        {
            _model.Tos *= xform.Matrix();
            RC.ModelView = View * _model.Tos;
        }
    }
}
