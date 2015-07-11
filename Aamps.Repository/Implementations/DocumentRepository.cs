using Aamps.Domain.Models;
using Aamps.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Repository.Implementations
{
    public class DocumentRepository: BaseRepository<DocumentDtl>, IDocumentRepository
    {
        public DocumentRepository(AampsContext context)
            : base(context)
        {
        }
    }
}
