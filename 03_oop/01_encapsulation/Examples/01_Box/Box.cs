namespace Box;

public class Box
{
    public Box(double height, double length, double width)
    {
        ValidateBoxDimentions(height, length, width);
        Height = height;
        Length = length;
        Width = width;
    }

    public double Height { get; init; }
    public double Length { get; init; }
    public double Width { get; init; }

    public double SurfaceArea() => 2 * (Width * Length + Height * Length + Height * Width);

    public double LateralSurfaceArea() => 2 * (Length * Width) * Height;

    public double Volume() => Width * Height * Length;

    private void ValidateBoxDimentions(double height, double length, double width)
    {
        ValidateGreaterThanZero(height, nameof(Height));
        ValidateGreaterThanZero(length, nameof(Length));
        ValidateGreaterThanZero(width, nameof(Width));
    }

    private void ValidateGreaterThanZero(double value, string propertyName)
    {
        if (value <= 0)
            throw new ArgumentException($"{propertyName} cannot be zero or negative.");
    }
}
