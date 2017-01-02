using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MRI.Neural
{
    public interface IProviderService
    {
        Network GetNetwork();
    }
}