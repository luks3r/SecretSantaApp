using DalBase = DataAccess.Interfaces.Base;

namespace BusinessLogic.Interfaces.Base
{
    public interface IBaseMapper<TLeftObject, TRightObject> : DalBase.IBaseMapper<TLeftObject, TRightObject>
    {
    }
}