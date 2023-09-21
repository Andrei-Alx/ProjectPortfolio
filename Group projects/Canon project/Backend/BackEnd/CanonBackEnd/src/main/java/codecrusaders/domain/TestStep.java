package codecrusaders.domain;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class TestStep {
    private Long id;
    private String testStepName;
    private Long subTestId;
    private Boolean testResult;
    private String description;
    private Long errorid;
}
