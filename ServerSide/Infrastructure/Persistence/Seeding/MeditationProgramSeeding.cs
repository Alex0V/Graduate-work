using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class MeditationProgramSeeding : ISeeder<MeditationProgram>
{
    private static readonly List<MeditationProgram> sessions = new List<MeditationProgram>()
    {
        new MeditationProgram()
        {
            Id = 1,
            MeditationId = 1,
            ProgramName = "Dreamy Breeze",
            FotoKey = "metta-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 2,
            MeditationId = 1,
            ProgramName = "Peace of the Lake",
            FotoKey = "6cd7496c-b1f0-4906-8df9-4ba5c93ba21e.png",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/6cd7496c-b1f0-4906-8df9-4ba5c93ba21e.png"
        },
        new MeditationProgram()
        {
            Id = 3,
            MeditationId = 2,
            ProgramName = "Silent Symphony",
            FotoKey = "zen-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/zen-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 4,
            MeditationId = 2,
            ProgramName = "Calm Waters",
            FotoKey = "mantra-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/mantra-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 5,
            MeditationId = 3,
            ProgramName = "Deep Equilibrium",
            FotoKey = "walking-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/walking-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 6,
            MeditationId = 3,
            ProgramName = "Transcendental Tranquility",
            FotoKey = "yoga-nidra-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/yoga-nidra-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 7,
            MeditationId = 4,
            ProgramName = "Path to Inner Peace",
            FotoKey = "kundalini-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/kundalini-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 8,
            MeditationId = 4,
            ProgramName = "Conscious Immersion",
            FotoKey = "open-monitoring-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/open-monitoring-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 9,
            MeditationId = 5,
            ProgramName = "Kindness Unfolding Practice",
            FotoKey = "metta-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 10,
            MeditationId = 5,
            ProgramName = "Radiant Love Meditation",
            FotoKey = "body-awareness-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-awareness-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 11,
            MeditationId = 6,
            ProgramName = "Meditation of Compassionate Hearts",
            FotoKey = "focused-attention-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/focused-attention-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 12,
            MeditationId = 6,
            ProgramName = "Mindful Body Unveiling",
            FotoKey = "silent-meditation.jpeg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/silent-meditation.jpeg"
        },
        new MeditationProgram()
        {
            Id = 13,
            MeditationId = 7,
            ProgramName = "Somatic Awareness Practice",
            FotoKey = "qi-gong-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/qi-gong-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 14,
            MeditationId = 7,
            ProgramName = "Sensory Body Exploration",
            FotoKey = "sound-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/sound-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 15,
            MeditationId = 8,
            ProgramName = "Insightful Mindfulness Practice",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 16,
            MeditationId = 8,
            ProgramName = "Quiet Stream",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 17,
            MeditationId = 9,
            ProgramName = "Breath count",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 18,
            MeditationId = 9,
            ProgramName = "Breathing harmony",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 19,
            MeditationId = 10,
            ProgramName = "The way to peace",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 20,
            MeditationId = 10,
            ProgramName = "Calm step",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 21,
            MeditationId = 11,
            ProgramName = "Visualization of dreams",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 22,
            MeditationId = 12,
            ProgramName = "Conscious immersion",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 23,
            MeditationId = 13,
            ProgramName = "Perception of sounds",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 24,
            MeditationId = 14,
            ProgramName = "Harmony of energy",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 25,
            MeditationId = 15,
            ProgramName = "Internal recovery",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 26,
            MeditationId = 16,
            ProgramName = "Perception of silence",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 27,
            MeditationId = 17,
            ProgramName = "Open observation",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 28,
            MeditationId = 18,
            ProgramName = "Internal focus",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 29,
            MeditationId = 19,
            ProgramName = "The perception of love",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new MeditationProgram()
        {
            Id = 30,
            MeditationId = 20,
            ProgramName = "Dive into inner space",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        }
    };

    public void Seed(EntityTypeBuilder<MeditationProgram> builder) => builder.HasData(sessions);
}
