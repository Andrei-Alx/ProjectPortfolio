package codecrusaders.domain;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.List;
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class TestBatch {
    private Long id;
    private String buildTime;
    private String version;
    private String commitShal;
    private LocalDateTime dateTime;
    private Long branchId;

}
