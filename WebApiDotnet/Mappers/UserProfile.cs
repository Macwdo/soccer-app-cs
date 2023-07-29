using AutoMapper;
using WebApiDotnet.Entities;
using WebApiDotnet.Model;

namespace WebApiDotnet.Mappers;

public class UserProfile: BaseProfile<UserEntity, UserRequest, UserResponse> {}