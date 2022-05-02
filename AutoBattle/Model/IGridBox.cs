
namespace AutoBattle.Model
{
    public interface IGridBox
    {
        sbyte xIndex { get; set; }
        sbyte yIndex { get; set; }
        bool ocupied { get; set; }
    }
}
