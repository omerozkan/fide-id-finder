using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIDE_ID_Finder.Model
{
    public enum ProgressStatus
    {
        DeletingOldFiles,
        Downloading,
        ConvertingFiles,
        Searching,
        Finished
    }
}
