﻿namespace WordCounter.Infrastructure.Settings.Processing
{
    public interface IProcessingSettingsProvider
    {
        ProcessingOption GetProcessingOption();
    }
}