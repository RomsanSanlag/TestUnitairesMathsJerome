using TuMaths3D;

public class MatrixElementaryOperations
{
    public static void SwapLines(MatrixInt m, int line1, int line2)
    {
        /*if (line1 < 0 || line1 >= m.NbLines || line2 < 0 || line2 >= m.NbLines)
        {
            throw new ArgumentOutOfRangeException("Line indices must be within matrix dimensions.");
        }*/
        
        for (int i = 0; i < m.NbColumns; i++)
        {
            int temp = m[line1, i];
            m[line1, i] = m[line2, i];
            m[line2, i] = temp;
        }
    }
    
    public static void SwapColumns(MatrixInt m, int col1, int col2)
    {
        /*if (col1 < 0 || col1 >= m.NbColumns || col2 < 0 || col2 >= m.NbColumns)
        {
            throw new ArgumentOutOfRangeException("Column indices must be within matrix dimensions.");
        }*/
        
        for (int i = 0; i < m.NbLines; i++)
        {
            int temp = m[i, col1];
            m[i, col1] = m[i, col2];
            m[i, col2] = temp;
        }
    }
    
    public static void MultiplyLine(MatrixInt m, int line, int factor)
    {
        if (factor == 0)
        {
            throw new MatrixScalarZeroException("Scalar factor cannot be zero.");
        }
        
        for (int i = 0; i < m.NbColumns; i++)
        {
            m[line, i] *= factor;
        }
    }
    
    public static void MultiplyColumn(MatrixInt m, int column, int factor)
    {
        if (factor == 0)
        {
            throw new MatrixScalarZeroException("Scalar factor cannot be zero.");
        }
        
        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, column] *= factor;
        }
    }
    
    public static void AddLineToAnother(MatrixInt m, int targetLine, int sourceLine, int factor)
    {
        for (int i = 0; i < m.NbColumns; i++)
        {
            m[sourceLine, i] += m[targetLine, i] * factor;
        }
    }

    public static void AddColumnToAnother(MatrixInt m, int targetColumn, int sourceColumn, int factor)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, sourceColumn] += m[i, targetColumn] * factor;
        }
    }
}