using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.DataStructures
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string PropertyName { get; }

        public PrimaryKeyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

    public class Post
    {
        [PrimaryKey("PostOwnerId")]
        public Guid PostOwnerId { get; set; }

        public List<string> Texts { get; set; }

        public DateTime SharedTime { get; set; }
    }
}
