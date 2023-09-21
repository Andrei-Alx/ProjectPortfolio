package codecrusaders.domain;

import lombok.Builder;
import lombok.Data;

import java.util.List;

@Data
@Builder
public class GetSubTestsResponse {
    private List<SubTest> subTests;
}
