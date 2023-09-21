package codecrusaders.repository.entity;

import codecrusaders.domain.RegressionTest;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

@Entity
@Data
@Table(name = "testbatches")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class TestBatchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "testbatchid")
    private Long id;
    @Column(name = "build_time")
    private String buildTime;
    @Column(name = "version")
    private String version;
    @Column(name = "commitShal")
    private String commitShal;
    @Column(name = "testbatchdate")
    private LocalDateTime dateTime;

    @Column(name = "branchid")
    private Long branchId;


}
