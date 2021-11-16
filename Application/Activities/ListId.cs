using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class ListId{
        public class QueryId : IRequest<Activity>{
            public Guid _id;          
            public QueryId(Guid id){
                _id = id;               
            }      
        }   
    public class Handler : IRequestHandler<QueryId, Activity>
        {
             private readonly DataContext _context;
            public Handler(DataContext context){
                _context = context;
            }
            public async Task<Activity> Handle(QueryId request, CancellationToken cancellationToken){
                return await _context.Activities.FindAsync(request._id);
            }
    }
    }     
}