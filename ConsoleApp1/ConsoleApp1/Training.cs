using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Training
    {

        NeuralNetwork net = new NeuralNetwork(new int[] { 3, 25, 25, 1 }); //intiilize network

        //Itterate 5000 times and train each possible output
        //5000*8 = 40000 traning operations
        public Training()
        {
            for (int i = 0; i < 9000; i++)
            {
                net.FeedForward(new float[] { 0, 0, 0, 0 });
                net.BackProp(new float[] { 0 });

                net.FeedForward(new float[] { 0, 0, 1, 0 });
                net.BackProp(new float[] { 1 });

                net.FeedForward(new float[] { 0, 1, 0, 0 });
                net.BackProp(new float[] { 1 });

                net.FeedForward(new float[] { 0, 1, 1, 0 });
                net.BackProp(new float[] { 0 });

                net.FeedForward(new float[] { 1, 0, 0, 0 });
                net.BackProp(new float[] { 1 });

                net.FeedForward(new float[] { 1, 0, 1, 0 });
                net.BackProp(new float[] { 0 });

                net.FeedForward(new float[] { 1, 1, 0, 0 });
                net.BackProp(new float[] { 0 });

                net.FeedForward(new float[] { 1, 1, 1, 0 });
                net.BackProp(new float[] { 1 });
            }


            //output to see if the network has learnt
            //WHICH IT HAS!!!!!
            Console.WriteLine(net.FeedForward(new float[] { 0, 0, 0 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 0, 0, 1 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 0, 1, 0 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 0, 1, 1 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 1, 0, 0 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 1, 0, 1 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 1, 1, 0 })[0]);
            Console.WriteLine(net.FeedForward(new float[] { 1, 1, 1 })[0]);
        }
       


    }
}
