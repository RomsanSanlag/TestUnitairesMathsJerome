using TuMaths3D;

public class MatrixSumException : Exception
{
    public MatrixSumException(string message) : base(message) { }
}

public class MatrixMultiplyException : Exception
{
    public MatrixMultiplyException(string message) : base(message){ }
}

public class MatrixScalarZeroException : Exception
{
    public MatrixScalarZeroException(string message) : base(message){ }

}