package codecrusaders.domain;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class CountFailedTestStepResponse {
    private int failedCounter;
}
