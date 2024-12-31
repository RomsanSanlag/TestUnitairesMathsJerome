
using TuMaths3D;

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
        _matrice = new int[m.NbLines, m.NbColumns];

        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                _matrice[i, j] = m[i, j];
            }
        }
    }

    //Propriété
    public int NbLines
    {
        get => _matrice.GetLength(0);
    }

    public int NbColumns
    {
        get => _matrice.GetLength(1);
    }

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
        return Multiply(this, factor);
    }

    public static MatrixInt Multiply(MatrixInt matrice, int factor)
    {
        int rows = matrice.NbLines;
        int cols = matrice.NbColumns;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrice[i, j] * factor;
            }
        }

        return new MatrixInt(result);
    }

    public static MatrixInt operator *(MatrixInt m, int scalar)
    {
        return Multiply(m, scalar);
    }

    public static MatrixInt operator -(MatrixInt m)
    {
        int rows = m._matrice.GetLength(0);
        int cols = m._matrice.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = -m._matrice[i, j];
            }
        }

        return new MatrixInt(result);
    }

    public void Add(MatrixInt m)
    {
        if (this.NbLines != m.NbLines || this.NbColumns != m.NbColumns)
        {
            throw new MatrixSumException("Matrices must have the same dimensions to be added.");
        }

        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                _matrice[i, j] += m[i, j];
            }
        }
    }

    public static MatrixInt Add(MatrixInt m1, MatrixInt m2)
    {
        if (m1.NbLines != m2.NbLines || m1.NbColumns != m2.NbColumns)
        {
            throw new MatrixSumException("Matrices must have the same dimensions to be added.");
        }

        int rows = m1.NbLines;
        int cols = m1.NbColumns;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return new MatrixInt(result);
    }

    public static MatrixInt operator +(MatrixInt m1, MatrixInt m2)
    {
        return Add(m1, m2);
    }

    public static MatrixInt Subtract(MatrixInt m1, MatrixInt m2)
    {
        if (m1.NbLines != m2.NbLines || m1.NbColumns != m2.NbColumns)
        {
            throw new InvalidOperationException("Matrices must have the same dimensions to be added.");
        }

        int rows = m1.NbLines;
        int cols = m1.NbColumns;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m1[i, j] - m2[i, j];
            }
        }

        return new MatrixInt(result);
    }

    public static MatrixInt operator -(MatrixInt m1, MatrixInt m2)
    {
        return Subtract(m1, m2);
    }

    //multiply matrice with matrice
    public MatrixInt Multiply(MatrixInt m)
    {
        if (this.NbColumns != m.NbLines)
        {
            throw new MatrixMultiplyException("Matrix dimensions must match for multiplication.");
        }

        int rows = this.NbLines;
        int cols = m.NbColumns;
        int common = this.NbColumns;

        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < common; k++)
                {
                    result[i, j] += this[i, k] * m[k, j];
                }
            }
        }

        return new MatrixInt(result);
    }

    public static MatrixInt Multiply(MatrixInt m1, MatrixInt m2)
    {
        return m1.Multiply(m2);
    }

    public static MatrixInt operator *(MatrixInt m1, MatrixInt m2)
    {
        return Multiply(m1, m2);
    }

    //Transpose matrice
    public MatrixInt Transpose()
    {
        int rows = this.NbColumns;
        int cols = this.NbLines;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < this.NbLines; i++)
        {
            for (int j = 0; j < this.NbColumns; j++)
            {
                result[j, i] = this[i, j];
            }
        }

        return new MatrixInt(result);
    }

    public static MatrixInt Transpose(MatrixInt m)
    {
        return m.Transpose();
    }

    //augmented matrice
    public static MatrixInt GenerateAugmentedMatrix(MatrixInt m1, MatrixInt m2)
    {
        int rows = m1.NbLines;
        int cols = m1.NbColumns + 1;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < m1.NbColumns; j++)
            {
                result[i, j] = m1[i, j];
            }

            result[i, m1.NbColumns] = m2[i, 0];
        }

        return new MatrixInt(result);
    }

    //split matrice
    public (MatrixInt, MatrixInt) Split(int n)
    {
        n += 1; //pour prendre le 0 en compte

        int[,] part1 = new int[NbLines, n];
        int[,] part2 = new int[NbLines, NbColumns - n];

        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < n; j++)
            {
                part1[i, j] = _matrice[i, j];
            }
        }

        for (int i = 0; i < NbLines; i++)
        {
            for (int j = n; j < NbColumns; j++)
            {
                part2[i, j - n] = _matrice[i, j];
            }
        }

        return (new MatrixInt(part1), new MatrixInt(part2));
    }
}

public class MatrixFloat
{
    private float[,] _matrice;

    // Constructor
    public MatrixFloat(float[,] matrix)
    {
        _matrice = matrix;
    }

    // Get number of rows
    public int NbLines => _matrice.GetLength(0);

    // Get number of columns
    public int NbColumns => _matrice.GetLength(1);

    // Convert matrix to 2D array
    public float[,] ToArray2D()
    {
        return _matrice;
    }

    // submatrix
    public MatrixFloat SubMatrix(int row, int col)
    {
        int rows = NbLines - 1;
        int cols = NbColumns - 1;
        
        float[,] subMatrix = new float[rows, cols];
        
        int subMatrixRow = 0;
        for (int i = 0; i < NbLines; i++)
        {
            if (i == row) continue;
            
            int subMatrixCol = 0;
            for (int j = 0; j < NbColumns; j++)
            {
                if (j == col) continue;
                
                subMatrix[subMatrixRow, subMatrixCol] = _matrice[i, j];
                subMatrixCol++;
            }
            subMatrixRow++;
        }

        return new MatrixFloat(subMatrix);
    }
    
    public static MatrixFloat SubMatrix(MatrixFloat matrix, int row, int col)
    {
        return matrix.SubMatrix(row, col);
    }
    
    //determinant
    public static float Determinant(MatrixFloat matrix)
    {
        if (matrix.NbLines == 2 && matrix.NbColumns == 2)
        {
            return (matrix._matrice[0, 0] * matrix._matrice[1, 1]) - (matrix._matrice[0, 1] * matrix._matrice[1, 0]);
        }
        if (matrix.NbLines == 3 && matrix.NbColumns == 3)
        {
            return CofactorDeterminant3x3(matrix);
        }

        if (matrix.NbLines == 4 && matrix.NbColumns == 4)
        {
            return CofactorDeterminant4x4(matrix);
        }
        
        throw new InvalidOperationException();
    }
    
    private static float CofactorDeterminant3x3(MatrixFloat matrix)
    {
        float a = matrix._matrice[0, 0], b = matrix._matrice[0, 1], c = matrix._matrice[0, 2];
        float d = matrix._matrice[1, 0], e = matrix._matrice[1, 1], f = matrix._matrice[1, 2];
        float g = matrix._matrice[2, 0], h = matrix._matrice[2, 1], i = matrix._matrice[2, 2];

        return a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
    }
    
        private static float CofactorDeterminant4x4(MatrixFloat matrix)
    {
        float determinant = 0f;
        
        for (int j = 0; j < 4; j++)
        {
            MatrixFloat minor = GetMinor(matrix, 0, j);
            
            float sign = (j % 2 == 0) ? 1f : -1f;
            
            determinant += sign * matrix._matrice[0, j] * CofactorDeterminant3x3(minor);
        }

        return determinant;
    }
    
    private static MatrixFloat GetMinor(MatrixFloat matrix, int row, int col)
    {
        float[,] minor = new float[3, 3];
        int minorRow = 0;
        
        for (int i = 0; i < 4; i++)
        {
            if (i == row) continue;

            int minorCol = 0;

            for (int j = 0; j < 4; j++)
            {
                if (j == col) continue;

                minor[minorRow, minorCol] = matrix._matrice[i, j];
                minorCol++;
            }

            minorRow++;
        }

        return new MatrixFloat(minor);
    }
    
    //identity
    public static MatrixFloat Identity(int size)
    {
        float[,] identityMatrix = new float[size, size];
        
        for (int i = 0; i < size; i++)
        {
            identityMatrix[i, i] = 1f;
        }
        
        return new MatrixFloat(identityMatrix);
    }
    
    //adjugate
    public MatrixFloat Adjugate()
    {
        if (NbLines == 2 && NbColumns == 2)
        {
            return Adjugate2x2();
        }
        throw new NotImplementedException();
    }
    
    private MatrixFloat Adjugate2x2()
    {
        float a = _matrice[0, 0];
        float b = _matrice[0, 1];
        float c = _matrice[1, 0];
        float d = _matrice[1, 1];
        
        float[,] adjugateMatrix = new float[,] 
        {
            { d, -b },
            { -c, a }
        };

        return new MatrixFloat(adjugateMatrix);
    }
    
    public static MatrixFloat Adjugate(MatrixFloat m)
    {
        return m.Adjugate();
    }
}