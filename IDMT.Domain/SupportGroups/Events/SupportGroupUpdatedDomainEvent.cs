﻿using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.SupportGroups.Events;

public sealed record SupportGroupUpdatedDomainEvent(Guid SupportGroupId) : IDomainEvent;
