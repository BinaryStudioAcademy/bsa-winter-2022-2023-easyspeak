namespace EasySpeak.RS.WebAPI.Helpers;

public static class QueryHelper
{
    public static string AddUserQuery 
        => @"MERGE (u:User { id: $id, fullName: $fullName })
            MERGE (c:Country { name: $country})
            MERGE (l:Language { name: $language })
            MERGE (lvl:LanguageLevel { name: $languageLevel })
            MERGE (a:AgeCategory { name: $ageGroup})
            MERGE (u)-[:LIVES_IN { weight: 4 }]->(c)
            MERGE (u)-[:TALKS_IN { weight: 2 }]->(l)
            MERGE (u)-[:LEVEL_IS { weight: 2 }]->(lvl)
            MERGE (u)-[:AGE_IS { weight: 2 }]->(a)";

    public static string UpdateUserQuery
        => @"MATCH (u:User { id: $id })
            SET u.fullName = $fullName
            WITH u
            OPTIONAL MATCH (u)-[oldLivesIn: LIVES_IN]->(oldCountry)
            WHERE oldCountry.name <> $country
            DELETE oldLivesIn
            WITH u
            OPTIONAL MATCH (u)-[oldTalksIn: TALKS_IN]->(oldLanguage)
            WHERE oldLanguage.name <> $language
            DELETE oldTalksIn
            WITH u
            OPTIONAL MATCH (u)-[oldLevelIs: LEVEL_IS]->(oldLanguageLevel)
            WHERE oldLanguageLevel.name <> $languageLevel
            DELETE oldLevelIs
            WITH u
            OPTIONAL MATCH (u)-[oldAgeIs: AGE_IS]->(oldAgeCategory)
            WHERE oldAgeCategory.age <> $age
            DELETE oldAgeIs
            WITH u
            MERGE (c:Country { name: $country })
            MERGE (l:Language { name: $language })
            MERGE (lvl:LanguageLevel { name: $languageLevel })
            MERGE (a:AgeCategory { age: $age })
            MERGE (u)-[:LIVES_IN { weight: 4 }]->(c)
            MERGE (u)-[:TALKS_IN { weight: 2 }]->(l)
            MERGE (u)-[:LEVEL_IS { weight: 2 }]->(lvl)
            MERGE (u)-[:AGE_IS { weight: 2 }]->(a)"; 

    public static string RemoveTagsQuery
        => @"MATCH(user:User { id: $id })-[relations:INTERESTED_IN]-(topics)
            DELETE relations";

    public static string AddTagsQuery 
        => @"WITH $tags as tags, $id as userId 
            MATCH (u: User {id: userId})
            UNWIND tags as tag
            MERGE (t: Topic {name: tag})
            MERGE (u)-[:INTERESTED_IN { weight: 2 }]->(t)";
    
    public static string AddClassQuery
        => @"MATCH (u: User { id: $id })
            MERGE (c: Class { id: $classId, name: $className })
            WITH u as user, c as class
            MERGE (user)-[:SUBSCRIBED_ON {weight: 2}]->(class)";

    public static string GetRecommendedUsersQuery
        => @"MATCH (user:User { id: $id })-[r:LIVES_IN|SUBSCRIBED_ON|TALKS_IN|INTERESTED_IN|LEVEL_IS|AGE_IS]->(shared)
            WITH user, COLLECT(DISTINCT shared) as sharedNodes, SUM(r.weight) as maxWeight
            MATCH (similar:User)-[rr:LIVES_IN|SUBSCRIBED_ON|TALKS_IN|INTERESTED_IN|LEVEL_IS|AGE_IS]->(shared2)
            WHERE similar.id IN $users AND NOT similar.id = $id
            WITH similar, COLLECT(DISTINCT shared2) as sharedNodes2, sharedNodes, maxWeight
            WITH similar, apoc.coll.intersection(sharedNodes, sharedNodes2) as commonNodes, maxWeight
            MATCH (similar:User)-[r:LIVES_IN|SUBSCRIBED_ON|TALKS_IN|INTERESTED_IN|LEVEL_IS|AGE_IS]->(similarNodes)
            WHERE similarNodes in commonNodes
            WITH similar, SUM(r.weight) as commonWeight, maxWeight
            WITH similar, commonWeight * 100 / maxWeight as percentage
            ORDER BY percentage DESC
            WHERE percentage > $compatibility
            RETURN COLLECT(similar.id)";
}