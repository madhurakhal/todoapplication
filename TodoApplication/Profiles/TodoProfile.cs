using AutoMapper;
using TodoApplication.Data;
using TodoApplication.Dtos;

namespace TodoApplication.Profiles
{
    public class TodoProfile: Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>();
        }
    }
}