using System.Collections;
using System.Collections.Generic;

public interface IDamagable
{
    void GetDamage(float damage);
    void GetHealing(float healing);
    void DieHandler();

}
