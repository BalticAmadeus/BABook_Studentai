using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookStudentai.Entities;
using Newtonsoft.Json;

namespace BaBookStudentai.DTOs
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }

        internal static List<GroupDto> Convert(IQueryable<Group> groups)
        {
            var list = new List<GroupDto>();
            foreach (var g in groups)
            {
                var groupDto = new GroupDto
                {
                    GroupId = g.GroupId,
                    Name = g.Name
                };
                list.Add(groupDto);
            }
            return list;
        }
    }
}