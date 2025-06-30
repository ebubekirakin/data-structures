/*
    FullBinaryTree.cs
    ------------------

    Manual implementation of a full binary tree in C# with traversal methods.
    (C# dilinde tam ikili ağacın manuel kurulumu ve dolaşım yöntemleri)

    İçerik:
    - Full binary tree node structure
    - Manual node additions (manual setup)
    - Tree traversal: InOrder, PreOrder, PostOrder

*/



using System;


namespace FullBinaryTreeExample
{
    // Binary Tree Node (İkili Ağaç Düğümü)
    public class IkiliAgacDugumu
    {
        public int veri;                     // Node data (veri)
        public IkiliAgacDugumu sol;          // Left child (sol çocuk)
        public IkiliAgacDugumu sag;          // Right child (sağ çocuk)

        // Constructor
        public IkiliAgacDugumu(int veri)
        {
            this.veri = veri;
            this.sol = null;
            this.sag = null;
        }
    }

    class Program
    {
        // Düğüm oluşturma metodu
        public static IkiliAgacDugumu DugumOlustur(int veri)
        {
            return new IkiliAgacDugumu(veri);
        }

        static void Main(string[] args)
        {
            // Ağaç yapısı (Full Binary Tree):
            //         10
            //        /  \
            //      20    30
            //     / \    / \
            //   40  50  60  70

            IkiliAgacDugumu kok = DugumOlustur(10);

            kok.sol = DugumOlustur(20);
            kok.sag = DugumOlustur(30);

            kok.sol.sol = DugumOlustur(40);
            kok.sol.sag = DugumOlustur(50);

            kok.sag.sol = DugumOlustur(60);
            kok.sag.sag = DugumOlustur(70);

            // Ağaç dolaşımları
            Console.WriteLine("InOrder:");
            InOrder(kok);

            Console.WriteLine("\nPreOrder:");
            PreOrder(kok);

            Console.WriteLine("\nPostOrder:");
            PostOrder(kok);
        }

        static void InOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;
            InOrder(dugum.sol);
            Console.Write(dugum.veri + " ");
            InOrder(dugum.sag);
        }

        static void PreOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;
            Console.Write(dugum.veri + " ");
            PreOrder(dugum.sol);
            PreOrder(dugum.sag);
        }

        static void PostOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;
            PostOrder(dugum.sol);
            PostOrder(dugum.sag);
            Console.Write(dugum.veri + " ");
        }
    }
}
