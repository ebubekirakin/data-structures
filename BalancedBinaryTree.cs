/*
    BalancedBinaryTree.cs
    -----------------------

    Manual implementation of a balanced binary tree in C#.
    (C# dilinde dengeli ikili ağacın manuel kurulumu)

    İçerik:
    - Balanced binary tree node yapısı
    - Manuel dengeli ağaç kurulumu (yükseklik dengesi korunarak)
    - Ağaç dolaşım yöntemleri: InOrder, PreOrder, PostOrder

*/


using System;

namespace BalancedBinaryTreeExample
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

    public class BalancedBinaryTree
    {
        public Dugum kok;

        public BalancedBinaryTree()
        {
            kok = null;
        }

        /*
            Dengeli bir yapı örneği (yükseklik farkı en fazla 1):

                   10
                 /    \
                5      15
               / \    / 
              3   7  12  
        */

        public void AgacOlustur()
        {
            kok = new Dugum(10);
            kok.sol = new Dugum(5);
            kok.sag = new Dugum(15);

            kok.sol.sol = new Dugum(3);
            kok.sol.sag = new Dugum(7);
            kok.sag.sol = new Dugum(12);
            // Not: kok.sag.sag eksik bırakıldı → böylece yükseklik farkı korunmuş oldu
        }

        public void InOrder(Dugum dugum)
        {
            if (dugum == null) return;
            InOrder(dugum.sol);
            Console.Write(dugum.veri + " ");
            InOrder(dugum.sag);
        }

        public void PreOrder(Dugum dugum)
        {
            if (dugum == null) return;
            Console.Write(dugum.veri + " ");
            PreOrder(dugum.sol);
            PreOrder(dugum.sag);
        }

        public void PostOrder(Dugum dugum)
        {
            if (dugum == null) return;
            PostOrder(dugum.sol);
            PostOrder(dugum.sag);
            Console.Write(dugum.veri + " ");
        }

        public static void Main()
        {
            BalancedBinaryTree tree = new BalancedBinaryTree();
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
