// *********************************************************************************
//	<copyright file="RewriteResponseDTO.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Rewrite response data DTO.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.DTO
{
	/// <summary>
	/// The Rewrite response data DTO.
	/// </summary>
	public class RewriteResponseDTO
	{
		/// <summary>
		/// Gets or sets the rewritten story data
		/// </summary>
		/// <value>
		/// The rewritten story data.
		/// </value>
		public string RewrittenStory { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the tokens consumed.
		/// </summary>
		/// <value>
		/// The tokens consumed.
		/// </value>
		public int TokensConsumed { get; set; }
	}
}
