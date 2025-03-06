// *********************************************************************************
//	<copyright file="GeminiAiRequestDto.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Gemini ai request dto.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.DTO
{
    /// <summary>
    /// Gemini ai request dto.
    /// </summary>
    public class GeminiAiRequestDto
    {
        /// <summary>
        /// Gets or sets the contents.
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        public List<Content> contents { get; set; }
    }

    /// <summary>
    /// The Content data dto.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public List<Part> parts { get; set; }
    }

    /// <summary>
    /// The Part Data DTO.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string text { get; set; }
    }
}