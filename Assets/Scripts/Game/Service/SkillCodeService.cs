namespace Game.Service {

    public interface ISkillCodeService : IInitService {
        int GetCurrentSkillcode(InputButton button, int currentCode);
    }

    public class SkillCodeService {

    }
}