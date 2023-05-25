using System;

namespace dotRMDY.Components.Shared.Services.Implementations
{
    /// <summary>
    ///     Time keeper providing information from <see cref="DateTime" />, <see cref="DateTimeOffset" /> and
    ///     <see cref="TimeZoneInfo" />
    /// </summary>
    public class TimeKeeper : ITimeKeeper
    {
        /// <inheritdoc />
        public DateTimeOffset NowOffset => DateTimeOffset.Now;

        /// <inheritdoc />
        public DateTime Now => DateTime.Now;

        /// <inheritdoc />
        public DateTimeOffset UtcNowOffset => DateTimeOffset.UtcNow;

        /// <inheritdoc />
        public DateTime UtcNow => DateTime.UtcNow;

        /// <inheritdoc />
        public DateTimeOffset DefaultOffset => default;

        /// <inheritdoc />
        public DateTime Default => default;

        /// <inheritdoc />
        public DateTimeOffset MinValueOffset => DateTimeOffset.MinValue;

        /// <inheritdoc />
        public DateTime MinValue => DateTime.MinValue;

        /// <inheritdoc />
        public DateTimeOffset MaxValueOffset => DateTimeOffset.MaxValue;

        /// <inheritdoc />
        public DateTime MaxValue => DateTime.MaxValue;

        /// <inheritdoc />
        public TimeZoneInfo LocalTimeZone => TimeZoneInfo.Local;

        /// <inheritdoc />
        public TimeZoneInfo UtcTimeZone => TimeZoneInfo.Utc;

        /// <inheritdoc />
        public DateTime Today => DateTime.Today;
    }
}