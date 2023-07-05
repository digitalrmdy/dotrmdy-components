using System;
using JetBrains.Annotations;

namespace dotRMDY.Components.Services
{
	/// <summary>
	///     Class providing the current time
	/// </summary>
	[PublicAPI]
	public interface ITimeKeeper
	{
		/// <summary>
		///     Now with the current offset
		/// </summary>
		DateTimeOffset NowOffset { get; }

		/// <summary>
		///     Now
		/// </summary>
		DateTime Now { get; }

		/// <summary>
		///     Now in UTC with the current offset (so no offset)
		/// </summary>
		DateTimeOffset UtcNowOffset { get; }

		/// <summary>
		///     Now in UTC
		/// </summary>
		DateTime UtcNow { get; }

		/// <summary>
		///     Default value with offset
		/// </summary>
		DateTimeOffset DefaultOffset { get; }

		/// <summary>
		///     Default value
		/// </summary>
		DateTime Default { get; }

		/// <summary>
		///     Minimum value with offset
		/// </summary>
		DateTimeOffset MinValueOffset { get; }

		/// <summary>
		///     Minimum value
		/// </summary>
		DateTime MinValue { get; }

		/// <summary>
		///     Maximum value with offset
		/// </summary>
		DateTimeOffset MaxValueOffset { get; }

		/// <summary>
		///     Maximum value
		/// </summary>
		DateTime MaxValue { get; }

		/// <summary>
		///     Current local time zone
		/// </summary>
		TimeZoneInfo LocalTimeZone { get; }

		/// <summary>
		///     The UTC time zone
		/// </summary>
		TimeZoneInfo UtcTimeZone { get; }
		
		/// <summary>
		///     Today
		/// </summary>
		DateTime Today { get; }
	}
}