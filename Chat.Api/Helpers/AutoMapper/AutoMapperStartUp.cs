using AutoMapper;
using Chat.Data.Domain;
using Chat.DataModel.Pcl.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Api.Helpers.AutoMapper
{
    public class AutoMapperStartUp
    {
        public void Run()
        {
            Mapper.CreateMap<BaseEntity, BaseEntityDataModel>();
            Mapper.CreateMap<User, UserDataModel>();
            Mapper.CreateMap<UserDataModel, User>();

            Mapper.CreateMap<Message, MessageDataModel>();
            Mapper.CreateMap<MessageDataModel, Message>();
        }
    }
}