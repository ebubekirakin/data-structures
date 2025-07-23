/*
    BinaryTreeImplementation.cs
    ----------------------------

    Manual implementation of a general binary tree in C#.
    (C# dilinde genel bir ikili ağacın manuel kurulumu)

    İçerik:
    - Binary tree node class
    - Custom tree structure example

*/





using System;

namespace BinaryTreeExample
{
    // Binary Tree Node (İkili Ağaç Düğümü)
    public class IkiliAgacDugumu
    {
        public int veri;                     // Node data (veri)
        public IkiliAgacDugumu sol;          // Left child (sol çocuk)
        public IkiliAgacDugumu sag;          // Right child (sağ çocuk)

        // Constructor (Yapıcı metot)
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

        // Ana program
        static void Main(string[] args)
        {
            // Ağaç yapısı:
            //         4
            //        / \
            //       6   12
            //      /    / \
            //    45    7   1

            // Ağacı elle kuruyoruz
            IkiliAgacDugumu kok = DugumOlustur(4);

            kok.sol = DugumOlustur(6);
            kok.sol.sol = DugumOlustur(45);

            kok.sag = DugumOlustur(12);
            kok.sag.sol = DugumOlustur(7);
            kok.sag.sag = DugumOlustur(1);

            // Kontrol için ağacı dolaşıp yazdır
            Console.WriteLine("InOrder dolaşım:");
            InOrder(kok);

            Console.WriteLine("\nPreOrder dolaşım:");
            PreOrder(kok);

            Console.WriteLine("\nPostOrder dolaşım:");
            PostOrder(kok);
        }

        // InOrder traversal (L -> Root -> R)
        static void InOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;

            InOrder(dugum.sol);
            Console.Write(dugum.veri + " ");
            InOrder(dugum.sag);
        }

        // PreOrder traversal (Root -> L -> R)
        static void PreOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;

            Console.Write(dugum.veri + " ");
            PreOrder(dugum.sol);
            PreOrder(dugum.sag);
        }

        // PostOrder traversal (L -> R -> Root)
        static void PostOrder(IkiliAgacDugumu dugum)
        {
            if (dugum == null) return;

            PostOrder(dugum.sol);
            PostOrder(dugum.sag);
            Console.Write(dugum.veri + " ");
        }
    }
}
