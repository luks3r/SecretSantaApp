namespace DataAccess.Interfaces.Base
{
    public interface IBaseMapper<TLeftObject, TRightObject>
    {
        TLeftObject? Map(TRightObject? inObject);
        TRightObject? Map(TLeftObject inObject);
    }
}