﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Training
    {

        NeuralNetwork net = new NeuralNetwork(new int[] { 4, 25, 25, 4 }); //intiilize network

        //Itterate 5000 times and train each possible output
        //5000*8 = 40000 traning operations
        public Training()
        {
            for (int i = 0; i < 5000; i++)
            {
                net.FeedForward(new float[] { 1, 2, 3, 16 });
                net.BackProp(new float[] { 17, 18, 19, 20 });

                net.FeedForward(new float[] { 4, 5, 6, 0 });
                net.BackProp(new float[] { 17, 18, 19, 20 });

                net.FeedForward(new float[] { 7, 8, 9, 0 });
                net.BackProp(new float[] { 17, 18, 19, 20 });

                net.FeedForward(new float[] { 10, 11, 0, 0 });
                net.BackProp(new float[] { 17, 18, 19, 20 });

                //net.FeedForward(new float[] { 13, 14, 15, 0 });
                //net.BackProp(new float[] { 21 });

                //net.FeedForward(new float[] { 1, 0, 1, 0 });
                //net.BackProp(new float[] { 0 });

                //net.FeedForward(new float[] { 1, 1, 0, 0 });
                //net.BackProp(new float[] { 0 });

                //net.FeedForward(new float[] { 1, 1, 1, 0 });
                //net.BackProp(new float[] { 1 });
            }


            //output to see if the network has learnt
            //WHICH IT HAS!!!!!.
            Console.WriteLine("---------------");
            Console.WriteLine(net.FeedForward(new float[] { 1, 2, 3, 16 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 4, 5, 6, 0 })[1]);
            Console.WriteLine(net.FeedForward(new float[] { 7, 8, 9, 0 })[2]);
            Console.WriteLine(net.FeedForward(new float[] { 1, 2, 3, 16 })[3]);
            Console.WriteLine("---------------");
            //Console.WriteLine("---------------");
            //Console.WriteLine(net.FeedForward(new float[] { 10, 11, 0, 0 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 10, 11, 0, 0 })[1]);
            //Console.WriteLine(net.FeedForward(new float[] { 10, 11, 0, 0 })[2]);
            //Console.WriteLine(net.FeedForward(new float[] { 10, 11, 0, 0 })[3]);
            //Console.WriteLine("---------------");
            //Console.WriteLine(net.FeedForward(new float[] { 0, 0, 1 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 0, 1, 0 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 0, 1, 1 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 1, 0, 0 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 1, 0, 1 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 1, 1, 0 })[0]);
            //Console.WriteLine(net.FeedForward(new float[] { 1, 1, 1 })[0]);
        }
       


    }
}
