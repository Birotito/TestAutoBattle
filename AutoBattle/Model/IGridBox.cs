
namespace AutoBattle.Model
{
    public interface IGridBox
    {
        sbyte xIndex { get; set; }
        sbyte yIndex { get; set; }
        bool occupied { get; set; }
        void OccupyBox();
        void VacateBox();
    }
}
