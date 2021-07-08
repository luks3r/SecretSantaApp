﻿using AutoMapper;
using BusinessLogic.Interfaces.Base;

namespace BusinessLogic.Base
{
    public class BaseMapper<TLeftEntity, TRightEntity> : IBaseMapper<TLeftEntity, TRightEntity>
    {
        protected readonly IMapper Mapper;

        public BaseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        public TLeftEntity? Map(TRightEntity? inObject)
        {
            return Mapper.Map<TLeftEntity>(inObject);
        }

        public TRightEntity? Map(TLeftEntity? inObject)
        {
            return Mapper.Map<TRightEntity>(inObject);
        }
    }
}