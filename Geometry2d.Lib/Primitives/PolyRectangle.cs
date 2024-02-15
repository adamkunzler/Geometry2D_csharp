namespace Geometry2d.Lib.Primitives
{
    public class PolyRectangle : Polygon
    {
        public PolyRectangle(Vector2 position, Vector2 size) : this(position.X, position.Y, size.X, size.Y)
        {
        }

        public PolyRectangle(float posX, float posY, float width, float height)
        {
            Vertices.Add(new Vector2(posX, posY)); // top left
            Vertices.Add(new Vector2(posX + width, posY)); // top right
            Vertices.Add(new Vector2(posX + width, posY + height)); // bottom right
            Vertices.Add(new Vector2(posX, posY + height)); // bottom left
        }
    }
}