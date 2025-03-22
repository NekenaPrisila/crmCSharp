using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class GoogleDriveFile
{
    public uint Id { get; set; }

    public string? DriveFileId { get; set; }

    public string? DriveFolderId { get; set; }

    public uint? LeadId { get; set; }

    public uint? ContractId { get; set; }

    public virtual TriggerContract? Contract { get; set; }

    public virtual TriggerLead? Lead { get; set; }
}
