
using System;

namespace HeapTreeExample
{
    public class HeapTree
    {
        private int[] heapArray;
        private int kapasite;
        private int boyut;

        public HeapTree(int kapasite)
        {
            this.kapasite = kapasite;
            heapArray = new int[kapasite];
            boyut = 0;
        }

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        public void Insert(int deger)
        {
            if (boyut == kapasite)
            {
                Console.WriteLine("Heap dolu!");
                return;
            }

            int i = boyut;
            heapArray[boyut++] = deger;

            // Yukarı doğru heapify
            while (i != 0 && heapArray[Parent(i)] < heapArray[i])
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public int ExtractMax()
        {
            if (boyut <= 0)
                return int.MinValue;
            if (boyut == 1)
                return heapArray[--boyut];

            int root = heapArray[0];
            heapArray[0] = heapArray[--boyut];
            MaxHeapify(0);

            return root;
        }

        private void MaxHeapify(int i)
        {
            int enBuyuk = i;
            int sol = Left(i);
            int sag = Right(i);

            if (sol < boyut && heapArray[sol] > heapArray[enBuyuk])
                enBuyuk = sol;
            if (sag < boyut && heapArray[sag] > heapArray[enBuyuk])
                enBuyuk = sag;

            if (enBuyuk != i)
            {
                Swap(i, enBuyuk);
                MaxHeapify(enBuyuk);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heapArray[i];
            heapArray[i] = heapArray[j];
            heapArray[j] = temp;
        }

        public void Yazdir()
        {
            Console.Write("Heap elemanları: ");
            for (int i = 0; i < boyut; i++)
                Console.Write(heapArray[i] + " ");
            Console.WriteLine();
        }

        public static void Main()
        {
            HeapTree heap = new HeapTree(10);
            heap.Insert(40);
            heap.Insert(20);
            heap.Insert(30);
            heap.Insert(10);
            heap.Insert(50);

            heap.Yazdir(); // Max-Heap olarak yazdır

            Console.WriteLine("En büyük değer çıkarıldı: " + heap.ExtractMax());
            heap.Yazdir();
        }
    }
}
