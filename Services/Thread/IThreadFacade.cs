﻿using AstralForum.Data.Entities;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
    public interface IThreadFacade
    {
        ThreadTableViewModel GetThreadTableViewModel(ThreadDto threadDto);

        Task<ThreadDto> CreateThread(ThreadCreationFormModel threadForm, User createdById);
    }
}
