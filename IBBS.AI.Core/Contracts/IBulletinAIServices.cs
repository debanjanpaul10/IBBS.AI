// *********************************************************************************
//	<copyright file="IBulletinAIServices.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Bulletin Board AI services interface.</summary>
// *********************************************************************************


namespace IBBS.AI.Core.Contracts
{
	using IBBS.AI.Shared.DTO;

	/// <summary>
	/// Bulletin Board AI services interface.
	/// </summary>
	public interface IBulletinAIServices
	{
		/// <summary>
		/// Rewrites text async.
		/// </summary>
		/// <param name="story">The story.</param>
		/// <returns>The rewrite response dto.</returns>
		Task<RewriteResponseDTO> RewriteTextAsync(string story);
	}

}

