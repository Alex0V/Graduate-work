using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class ProgramContentSeeding : ISeeder<ProgramContent>
{
    private static readonly List<ProgramContent> programContent = new List<ProgramContent>()
    {
        new ProgramContent()
        {
            Id = 1,
            ContentName = "Day 1",
            Duration ="10:35",
            MeditationProgramId = 1,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Dreamy+Breeze.mp3",
            AudioKey = "Dreamy Breeze.mp3"

        },
        new ProgramContent()
        {
            Id = 2,
            ContentName = "Day 2",
            Duration ="10:30",
            MeditationProgramId = 1,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Peace+of+the+Lake.mp3",
            AudioKey = "Peace of the Lake.mp3"
        },
        new ProgramContent()
        {
            Id = 3,
            ContentName = "Day 3",
            Duration ="10:01",
            MeditationProgramId = 1,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Silent+Symphony.mp3",
            AudioKey = "Silent Symphony.mp3"
        },
        new ProgramContent()
        {
            Id = 4,
            ContentName = "Day 4",
            Duration ="20:32",
            MeditationProgramId = 1,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Calm+Waters.mp3",
            AudioKey = "Calm Waters.mp3"
        },
        new ProgramContent()
        {
            Id = 5,
            ContentName = "Day 5",
            Duration ="13:00",
            MeditationProgramId = 1,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Deep+Equilibrium.mp3",
            AudioKey = "Deep Equilibrium.mp3"
        },
        new ProgramContent()
        {
            Id = 6,
            ContentName = "Day 1",
            Duration ="20:26",
            MeditationProgramId = 2,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Transcendental+Tranquility.mp3",
            AudioKey = "Transcendental Tranquility.mp3"
        },
        new ProgramContent()
        {
            Id = 7,
            ContentName = "Day 2",
            Duration = "10:21",
            MeditationProgramId = 2,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Path+to+Inner+Peace.mp3",
            AudioKey = "Path to Inner Peace.mp3"
        },
        new ProgramContent()
        {
            Id = 8,
            ContentName = "Day 3",
            Duration = "26:31",
            MeditationProgramId = 2,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Conscious+Immersion.mp3",
            AudioKey = "Conscious Immersion.mp3"
        },
        new ProgramContent()
        {
            Id = 9,
            ContentName = "Day 1",
            Duration = "22:38",
            MeditationProgramId = 3,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Kindness+Unfolding+Practice.mp3",
            AudioKey = "Kindness Unfolding Practice.mp3"
        },
        new ProgramContent()
        {
            Id = 10,
            ContentName = "Day 2",
            Duration = "10:10",
            MeditationProgramId = 3,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Radiant+Love+Meditation.mp3",
            AudioKey = "Radiant Love Meditation.mp3"
        },
        new ProgramContent()
        {
            Id = 11,
            ContentName = "Day 3",
            Duration = "10:07",
            MeditationProgramId = 3,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Meditation+of+Compassionate+Hearts.mp3",
            AudioKey = "Meditation of Compassionate Hearts.mp3"
        },
        new ProgramContent()
        {
            Id = 12,
            ContentName = "Day 1",
            Duration = "21:26",
            MeditationProgramId = 4,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Mindful+Body+Unveiling.mp3",
            AudioKey = "Mindful Body Unveiling.mp3"
        },
        new ProgramContent()
        {
            Id = 13,
            ContentName = "Day 2",
            Duration = "11:38",
            MeditationProgramId = 4,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Somatic+Awareness+Practice.mp3",
            AudioKey = "Somatic Awareness Practice.mp3"
        },
        new ProgramContent()
        {
            Id = 14,
            ContentName = "Day 3",
            Duration = "10:00",
            MeditationProgramId = 4,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Sensory+Body+Exploration.mp3",
            AudioKey = "Sensory Body Exploration.mp3"
        },
        new ProgramContent()
        {
            Id = 15,
            ContentName = "Day 1",
            Duration = "30:02",
            MeditationProgramId = 5,
            S3UrlAudio = "https://medi-coursework.s3.eu-west-2.amazonaws.com/Insightful+Mindfulness+Practice.mp3",
            AudioKey = "Insightful Mindfulness Practice.mp3"
        }

    };

    public void Seed(EntityTypeBuilder<ProgramContent> builder) => builder.HasData(programContent);
}
