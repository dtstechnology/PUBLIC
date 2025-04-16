using Data.Access.Layer.DataContext;
using Data.Access.Layer.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.DataIO.Interfaces
{
    public interface ICRUD 
    {
        void Add(); 
        void Update(); 
        void Get(); 
        void GetAll(); 
        void Delete(); 
    }

}
