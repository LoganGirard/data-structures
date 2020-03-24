class UnionFind
    {    
        // Size of the group to which sz[i] belongs.
        int[] sz;
        
        // If id[i] = i, then the node is a root.
        int[] id;
        
        public int numComponents;
        
        public UnionFind(int size)
        {
            if (size <= 0) throw new ArgumentNullException($"{nameof(size)} cannot be <= 0");
            
            sz = new int[size];
            id = new int[size];
            
            for (int i=0; i<size; i++)
            {
                sz[i] = 1;
                id[i] = i;
            }
            
            numComponents = size;
        }
        
        public int Find(int p)
        {
            int root = p;
            while (root != id[root])
            {
                root = id[root];
            }
            
            // Path compression for amortized constant runtime complexity.
            while (p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }
            
            return root;
        }
        
        public void Union(int p, int q)
        {
            if (p == q) return;
            
            if (sz[p] > sz[q])
            {
                id[q] = id[p];    
            }
            else
            {
                id[p] = id[q];
            }
            
            sz[q] = sz[p] + sz[q];
            sz[p] = sz[q];
            
            numComponents--;
        }
    }
