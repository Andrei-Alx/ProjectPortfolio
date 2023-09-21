package codecrusaders.domain;

import lombok.*;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GetLatestTestsResponse {
    private List<RegressionTest> latestTests;
}
