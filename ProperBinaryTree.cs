/*
    ProperBinaryTree.cs
    --------------------

    Manual implementation of a proper binary tree in C#.
    (C# dilinde "her düğümün 0 veya 2 çocuğu" olan doğru ikili ağacın manuel kurulumu)

    İçerik:
    - Proper binary tree node structure
    - Manual tree construction
    - Tree traversal: PreOrder, InOrder, PostOrder

*/

using System;

namespace ProperBinaryTreeExample
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
    public class ProperBinaryTree
    {
        public Dugum kok;

        public ProperBinaryTree()
        {
            kok = null;
        }

        // Örnek olarak ağacı manuel oluşturuyoruz
        public void AgacOlustur()
        {
            /*
                Oluşturulan ağaç yapısı:

                         10
                        /  \
                      5     15
                     / \   /  \
                    2   7 12  20
            */

            kok = new Dugum(10);
            kok.sol = new Dugum(5);
            kok.sag = new Dugum(15);

            kok.sol.sol = new Dugum(2);
            kok.sol.sag = new Dugum(7);

            kok.sag.sol = new Dugum(12);
            kok.sag.sag = new Dugum(20);
        }

        // PreOrder traversal: Kök -> Sol -> Sağ
        public void PreOrder(Dugum dugum)
        {
            if (dugum == null) return;
            Console.Write(dugum.veri + " ");
            PreOrder(dugum.sol);
            PreOrder(dugum.sag);
        }

        // InOrder traversal: Sol -> Kök -> Sağ
        public void InOrder(Dugum dugum)
        {
            if (dugum == null) return;
            InOrder(dugum.sol);
            Console.Write(dugum.veri + " ");
            InOrder(dugum.sag);
        }

        // PostOrder traversal: Sol -> Sağ -> Kök
        public void PostOrder(Dugum dugum)
        {
            if (dugum == null) return;
            PostOrder(dugum.sol);
            PostOrder(dugum.sag);
            Console.Write(dugum.veri + " ");
        }

        // Main fonksiyonu
        public static void Main()
        {
            ProperBinaryTree tree = new ProperBinaryTree();
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
