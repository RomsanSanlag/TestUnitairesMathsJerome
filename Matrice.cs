
public class MatrixInt
{
    //Champs
    private int[,] _matrice = new int[1, 1];
    
    //Constructeurs
    public MatrixInt(int rows, int columns)
    {
        _matrice = new int[rows, columns];
    }

    public MatrixInt(int[,] rows)
    {
        _matrice = rows;
    }

    public MatrixInt(MatrixInt m)
    {
        _matrice = new int[m.NbLines,m.NbColumns];
        
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                _matrice[i, j] = m[i, j];
            }
        }
    }

    //Propriété
    public int NbLines { get => _matrice.GetLength(0); }
    public int NbColumns { get => _matrice.GetLength(1); }

    //Indexer
    public int this[int i, int j]
    {
        get { return _matrice[i, j]; }
        set { _matrice[i, j] = value; }
    }
    
    //Méthode
    public int[,] ToArray2D()
    {
        return _matrice;
    }

    public static MatrixInt Identity(int nb)
    {
        int[,] matrice = new int[nb, nb];
        
        for (int i = 0; i < nb; i++)
        {
            for (int j = 0; j < nb; j++)
            {
                if (i == j)
                {
                    matrice[i, j] = 1;
                }
                else
                {
                    matrice[i, j] = 0;
                }
            }
        }
        return new MatrixInt(matrice);
    }

    public bool IsIdentity()
    {
        if (NbLines != NbColumns)
        {
            return false;
        }
        
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                if (i == j)
                {
                    if (_matrice[i, j] != 1)
                    {
                        return false;
                    }
                }
                else if (i != j)
                {
                    if (_matrice[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public MatrixInt Multiply(int factor)
    {
        return (Multiply(this, factor));
    }

    public static MatrixInt Multiply(MatrixInt matrice, int factor)
    {
        for (int i = 0; i < matrice.NbLines; i++)
        {
            for (int j = 0; j < matrice.NbColumns; j++)
            {
                matrice[i, j] *= factor;
            }
        }
        return new MatrixInt(matrice);

    }
}