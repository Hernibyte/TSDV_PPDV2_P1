public interface IHittable{
    void Hit();
}

public interface IBreakable{
    void Break();
}

public interface IPowerUP{
    void ApplyPowerUp(int powerUpType);
}