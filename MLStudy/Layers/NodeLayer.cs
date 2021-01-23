﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Layers
{
    class NodeLayer
    {
        int N = 0;
        float[] paras;
        float[] bias;
        float[] datas;
        float[] origindata;

        float[] ddata;

        float learnRate = 1f;
        public NodeLayer(int N)
        {
            this.N = N;
            ddata = new float[N];
            paras = new float[N];
            bias = new float[1];
            Initiate();
        }

        public void Initiate()
        {
            paras = new float[] { 0.5f, 0.6f };
            bias = new float[] { 0.9f };
        }

        public float Calculate(float[] data)
        {
            datas = data;
            origindata = data;
            return Networks.ListMulAdd(datas, paras) + bias[0];
        }

        public float[] Callback(float x)
        {
            ddata = Networks.ListMulti(paras, x);

            bias[0] -= x;
            paras = Networks.ListDimi(paras, Networks.ListMulti(origindata, x * learnRate));
            return ddata;

        }
    }
}
