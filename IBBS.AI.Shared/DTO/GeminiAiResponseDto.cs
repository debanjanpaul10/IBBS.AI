// *********************************************************************************
//	<copyright file="GeminiAiResponseDto.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Gemini ai response dto.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.DTO
{
    /// <summary>
    /// Gemini ai response dto.
    /// </summary>
    public class GeminiAiResponseDto
    {
        /// <summary>
        /// Gets or sets the candidates.
        /// </summary>
        /// <value>
        /// The candidates.
        /// </value>
        public List<Candidate> Candidates { get; set; }

        /// <summary>
        /// Gets or sets the usage metadata.
        /// </summary>
        /// <value>
        /// The usage metadata.
        /// </value>
        public UsageMetadata UsageMetadata { get; set; }

        /// <summary>
        /// Gets or sets the model version.
        /// </summary>
        /// <value>
        /// The model version.
        /// </value>
        public string ModelVersion { get; set; }
    }

    /// <summary>
    /// Candidate.
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public Content Content { get; set; }

        /// <summary>
        /// Gets or sets the finish reason.
        /// </summary>
        /// <value>
        /// The finish reason.
        /// </value>
        public string FinishReason { get; set; }

        /// <summary>
        /// Gets or sets the avg logprobs.
        /// </summary>
        /// <value>
        /// The avg logprobs.
        /// </value>
        public double AvgLogprobs { get; set; }
    }

    /// <summary>
    /// Usage metadata.
    /// </summary>
    public class UsageMetadata
    {
        /// <summary>
        /// Gets or sets the prompt token count.
        /// </summary>
        /// <value>
        /// The prompt token count.
        /// </value>
        public int PromptTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the candidates token count.
        /// </summary>
        /// <value>
        /// The candidates token count.
        /// </value>
        public int CandidatesTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the total token count.
        /// </summary>
        /// <value>
        /// The total token count.
        /// </value>
        public int TotalTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the prompt tokens details.
        /// </summary>
        /// <value>
        /// The prompt tokens details.
        /// </value>
        public List<TokenDetail> PromptTokensDetails { get; set; }

        /// <summary>
        /// Gets or sets the candidates tokens details.
        /// </summary>
        /// <value>
        /// The candidates tokens details.
        /// </value>
        public List<TokenDetail> CandidatesTokensDetails { get; set; }
    }

    /// <summary>
    /// Token detail.
    /// </summary>
    public class TokenDetail
    {
        /// <summary>
        /// Gets or sets the modality.
        /// </summary>
        /// <value>
        /// The modality.
        /// </value>
        public string Modality { get; set; }

        /// <summary>
        /// Gets or sets the token count.
        /// </summary>
        /// <value>
        /// The token count.
        /// </value>
        public int TokenCount { get; set; }
    }
}