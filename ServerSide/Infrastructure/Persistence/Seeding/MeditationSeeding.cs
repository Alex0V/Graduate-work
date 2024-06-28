using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeding;

public class MeditationSeeding : ISeeder<Meditation>
{
    private static readonly List<Meditation> meditations = new List<Meditation>()
    {
         new Meditation()
        {
            Id = 1,
            Name = "Mindfulness Meditation",
            Description = "Focuses on being present in the moment and non-judgmentally observing your thoughts and surroundings.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "mindfulness-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/mindfulness-meditation.jpg"
        },
        new Meditation()
        {
            Id = 2,
            Name = "Transcendental Meditation",
            Description = "Uses a mantra to help quiet the mind and achieve a deep state of relaxation.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "transcendental-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/transcendental-meditation.jpg"
        },
        new Meditation()
        {
            Id = 3,
            Name = "Loving-Kindness Meditation",
            Description = "Involves generating feelings of love and compassion towards oneself and others.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "loving-kindness-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/loving-kindness-meditation.jpg"
        },
        new Meditation()
        {
            Id = 4,
            Name = "Body Scan Meditation",
            Description = "Involves systematically bringing attention to different parts of the body, noticing sensations and relaxing tension.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "body-scan-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-scan-meditation.jpg"
        },
        new Meditation()
        {
            Id = 5,
            Name = "Vipassana Meditation",
            Description = "Involves observing the breath and bodily sensations to gain insight into the nature of reality.",
            CreationDate = DateTime.Now,
            Duration = "30-60 minutes",
            FotoKey = "vipassana-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/vipassana-meditation.jpg"
        },
        new Meditation()
        {
            Id = 6,
            Name = "Zen Meditation",
            Description = "Involves sitting in silence and focusing on the breath, often with the support of a teacher or group.",
            CreationDate = DateTime.Now,
            Duration = "20-40 minutes",
            FotoKey = "zen-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/zen-meditation.jpg"
        },
        new Meditation()
        {
            Id = 7,
            Name = "Chakra Meditation",
            Description = "Involves focusing on each of the body's energy centers to balance and align them.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "chakra-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/chakra-meditation.jpg"
        },
        new Meditation()
        {
            Id = 8,
            Name = "Mantra Meditation",
            Description = "Involves repeating a word or phrase to focus the mind and achieve a calm state.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "mantra-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/mantra-meditation.jpg"
        },
        new Meditation()
        {
            Id = 9,
            Name = "Breath Counting Meditation",
            Description = "Involves counting each breath to maintain focus and concentration.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "breath-counting-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/breath-counting-meditation.jpg"
        },
        new Meditation()
        {
            Id = 10,
            Name = "Walking Meditation",
            Description = "Involves walking slowly and mindfully, focusing on each step and the sensations in the body.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "walking-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/walking-meditation.jpg"
        },
        new Meditation()
        {
            Id = 11,
            Name = "Visualization Meditation",
            Description = "Involves creating a mental image or scenario to promote relaxation and positive emotions.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "visualization-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/visualization-meditation.jpg"
        },
        new Meditation()
        {
            Id = 12,
            Name = "Yoga Nidra Meditation",
            Description = "Involves lying down and systematically relaxing different parts of the body to achieve a deep state of relaxation.",
            CreationDate = DateTime.Now,
            Duration = "20-40 minutes",
            FotoKey = "yoga-nidra-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/yoga-nidra-meditation.jpg"
        },
        new Meditation()
        {
            Id = 13,
            Name = "Sound Meditation",
            Description = "Involves focusing on a particular sound or a series of sounds to promote relaxation.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "sound-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/sound-meditation.jpg"
        },
        new Meditation()
        {
            Id = 14,
            Name = "Qi Gong Meditation",
            Description = "Involves combining movement, breath, and visualization to improve physical and mental health.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "qi-gong-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/qi-gong-meditation.jpg"
        },
        new Meditation()
        {
            Id = 15,
            Name = "Kundalini Meditation",
            Description = "Involves combining breathwork, movement, and mantra to awaken the energy at the base of the spine and raise it up through the chakras.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "kundalini-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/kundalini-meditation.jpg"
        },
        new Meditation()
        {
            Id = 16,
            Name = "Silent Meditation",
            Description = "Involves sitting in silence and observing the mind without judgment.",
            CreationDate = DateTime.Now,
            Duration = "10-60 minutes",
            FotoKey = "silent-meditation.jpeg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/silent-meditation.jpeg"
        },
        new Meditation()
        {
            Id = 17,
            Name = "Open Monitoring Meditation",
            Description = "Involves focusing on a specific object or sound to maintain concentration and develop awareness.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "open-monitoring-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/open-monitoring-meditation.jpg"
        },
        new Meditation()
        {
            Id = 18,
            Name = "Focused Attention Meditation",
            Description = "Involves focusing on a specific object or sound to maintain concentration and develop awareness.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "focused-attention-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/focused-attention-meditation.jpg"
        },
        new Meditation()
        {
            Id = 19,
            Name = "Metta Meditation",
            Description = "Involves cultivating feelings of loving-kindness and compassion towards oneself and others.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "metta-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/metta-meditation.jpg"
        },
        new Meditation()
        {
            Id = 20,
            Name = "Body Awareness Meditation",
            Description = "Involves focusing on the sensations in the body to develop awareness and relaxation.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "body-awareness-meditation.jpg",
            S3UrlFoto = "https://medi-coursework.s3.eu-west-2.amazonaws.com/body-awareness-meditation.jpg"
        },
        new Meditation()
        {
            Id = 21,
            Name = "Compassion Meditation",
            Description = "Involves cultivating feelings of empathy and compassion towards oneself and others.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 22,
            Name = "Singing Bowl Meditation",
            Description = "Involves listening to the sound of a singing bowl to promote relaxation and focus.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 23,
            Name = "Progressive Muscle Relaxation",
            Description = "Involves tensing and relaxing different muscle groups to promote relaxation and reduce tension.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 24,
            Name = "Guided Meditation",
            Description = "Involves following the instructions of a teacher or audio recording to promote relaxation and awareness.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 25,
            Name = "Mindful Eating Meditation",
            Description = "Involves eating slowly and mindfully, focusing on the taste, texture, and sensations of the food.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 26,
            Name = "Mindful Breathing Meditation",
            Description = "Involves focusing on the breath to promote relaxation and develop awareness.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 27,
            Name = "Compassionate Mind Meditation",
            Description = "Involves cultivating feelings of compassion and empathy towards oneself and others.",
            CreationDate = DateTime.Now,
            Duration = "",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 28,
            Name = "Spiritual Meditation",
            Description = "Involves connecting with a higher power or spiritual practice to promote relaxation and inner peace.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 29,
            Name = "Chanting Meditation",
            Description = "Involves repeating a sound or phrase to promote relaxation and focus.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        },
        new Meditation()
        {
            Id = 30,
            Name = "Third Eye Meditation",
            Description = "Involves focusing on the area between the eyebrows to promote relaxation and develop intuition.",
            CreationDate = DateTime.Now,
            Duration = "10-30 minutes",
            FotoKey = "",
            S3UrlFoto = ""
        }
    };

    public void Seed(EntityTypeBuilder<Meditation> builder) => builder.HasData(meditations);
}
