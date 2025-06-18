
using System;

namespace AvlTreeExample
{
    public class AvlNode
    {
        public int Veri;
        public AvlNode Sol;
        public AvlNode Sag;
        public int Yukseklik;

        public AvlNode(int veri)
        {
            Veri = veri;
            Yukseklik = 1;
        }
    }

    public class AvlTree
    {
        private AvlNode kok;

        public void Ekle(int veri)
        {
            kok = Ekle(kok, veri);
        }

        private AvlNode Ekle(AvlNode node, int veri)
        {
            if (node == null)
                return new AvlNode(veri);

            if (veri < node.Veri)
                node.Sol = Ekle(node.Sol, veri);
            else if (veri > node.Veri)
                node.Sag = Ekle(node.Sag, veri);
            else
                return node; // Aynı veri eklenmez

            node.Yukseklik = 1 + Math.Max(Yukseklik(node.Sol), Yukseklik(node.Sag));
            int denge = GetDenge(node);

            // LL Durumu
            if (denge > 1 && veri < node.Sol.Veri)
                return SagaDondur(node);

            // RR Durumu
            if (denge < -1 && veri > node.Sag.Veri)
                return SolaDondur(node);

            // LR Durumu
            if (denge > 1 && veri > node.Sol.Veri)
            {
                node.Sol = SolaDondur(node.Sol);
                return SagaDondur(node);
            }

            // RL Durumu
            if (denge < -1 && veri < node.Sag.Veri)
            {
                node.Sag = SagaDondur(node.Sag);
                return SolaDondur(node);
            }

            return node;
        }

        private int Yukseklik(AvlNode node)
        {
            return node?.Yukseklik ?? 0;
        }

        private int GetDenge(AvlNode node)
        {
            return node == null ? 0 : Yukseklik(node.Sol) - Yukseklik(node.Sag);
        }

        private AvlNode SolaDondur(AvlNode y)
        {
            AvlNode x = y.Sag;
            AvlNode T2 = x.Sol;

            x.Sol = y;
            y.Sag = T2;

            y.Yukseklik = Math.Max(Yukseklik(y.Sol), Yukseklik(y.Sag)) + 1;
            x.Yukseklik = Math.Max(Yukseklik(x.Sol), Yukseklik(x.Sag)) + 1;

            return x;
        }

        private AvlNode SagaDondur(AvlNode x)
        {
            AvlNode y = x.Sol;
            AvlNode T2 = y.Sag;

            y.Sag = x;
            x.Sol = T2;

            x.Yukseklik = Math.Max(Yukseklik(x.Sol), Yukseklik(x.Sag)) + 1;
            y.Yukseklik = Math.Max(Yukseklik(y.Sol), Yukseklik(y.Sag)) + 1;

            return y;
        }

        public void InOrder()
        {
            Console.Write("In-order gezinti: ");
            InOrder(kok);
            Console.WriteLine();
        }

        private void InOrder(AvlNode node)
        {
            if (node != null)
            {
                InOrder(node.Sol);
                Console.Write(node.Veri + " ");
                InOrder(node.Sag);
            }
        }

        public static void Main()
        {
            AvlTree avl = new AvlTree();
            avl.Ekle(30);
            avl.Ekle(20);
            avl.Ekle(40);
            avl.Ekle(10);
            avl.Ekle(25);
            avl.Ekle(50);
            avl.Ekle(5);

            avl.InOrder();  // Çıktı sıralı olacak
        }
    }
}
