
using System;

namespace CompleteBinaryTreeExample
{
    // Düğüm sınıfı
    public class Dugum
    {
        public int veri;
        public Dugum sol;
        public Dugum sag;

        public Dugum(int veri)
        {
            this.veri = veri;
            this.sol = null;
            this.sag = null;
        }
    }

    // Ağaç sınıfı
    public class CompleteBinaryTree
    {
        public Dugum kok;

        public CompleteBinaryTree()
        {
            kok = null;
        }

        // Ağaç yapısı:
        /*
                 1
               /   \
              2     3
             / \   /
            4   5 6
        */

        public void AgacOlustur()
        {
            kok = new Dugum(1);
            kok.sol = new Dugum(2);
            kok.sag = new Dugum(3);

            kok.sol.sol = new Dugum(4);
            kok.sol.sag = new Dugum(5);
            kok.sag.sol = new Dugum(6);
            // Sağ alt (kok.sag.sag) eksik, çünkü son seviye sola dayalı olarak dolmalı (complete binary tree kuralı)
        }

        // InOrder: Sol -> Kök -> Sağ
        public void InOrder(Dugum dugum)
        {
            if (dugum == null) return;
            InOrder(dugum.sol);
            Console.Write(dugum.veri + " ");
            InOrder(dugum.sag);
        }

        // PreOrder: Kök -> Sol -> Sağ
        public void PreOrder(Dugum dugum)
        {
            if (dugum == null) return;
            Console.Write(dugum.veri + " ");
            PreOrder(dugum.sol);
            PreOrder(dugum.sag);
        }

        // PostOrder: Sol -> Sağ -> Kök
        public void PostOrder(Dugum dugum)
        {
            if (dugum == null) return;
            PostOrder(dugum.sol);
            PostOrder(dugum.sag);
            Console.Write(dugum.veri + " ");
        }

        public static void Main()
        {
            CompleteBinaryTree tree = new CompleteBinaryTree();
            tree.AgacOlustur();

            Console.WriteLine("PreOrder:");
            tree.PreOrder(tree.kok);

            Console.WriteLine("\nInOrder:");
            tree.InOrder(tree.kok);

            Console.WriteLine("\nPostOrder:");
            tree.PostOrder(tree.kok);
        }
    }
}
